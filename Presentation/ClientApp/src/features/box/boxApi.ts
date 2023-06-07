
import {  EntityState, createEntityAdapter, createSelector } from "@reduxjs/toolkit";
import api from "../../store/api";
import { RootState } from "../../store";

export interface DataFile {
    id: number;
    userId: number;
    username: string;
    extention: string;
    isDeleted: boolean;
    size: number;
    name: string;
    systemName: string;
    createdDatetime: string;
    updatedDateTime: string;
    sharedDescription: string;
    downloadCount: number;
}
export const DATAFILE_URL = '/datafile';
export const STORAGE_URL = '/storage';

const dataFilesAdapter = createEntityAdapter<DataFile>();
const initialState = dataFilesAdapter.getInitialState();

export const boxApi = api.injectEndpoints({
    endpoints: (builder) => ({
        getAllFiles: builder.query<EntityState<DataFile>, void>({
            query: () => DATAFILE_URL,
            transformResponse(response: DataFile[]){
                var result = dataFilesAdapter.setMany(initialState, response);
                return result;
            },
            providesTags: ['DataFiles']
        }),
        deleteFile: builder.mutation<void, number>({
            query: (id: number)=> ({
                url: `${DATAFILE_URL}/${id}`,
                method: 'DELETE'
            }),
            invalidatesTags: ['DataFiles']
        }),
        shareFile: builder.mutation<void, any>({
            query: ({id , time}: any)=> ({
                url: `${DATAFILE_URL}/share/${id}/${time}`,
                method: 'GET'
            }),
            invalidatesTags: ['DataFiles']
        }),
        
    })
})

export const { 
    useGetAllFilesQuery, 
    useDeleteFileMutation, 
    useShareFileMutation,
} = boxApi;

export const selectDataFileResult = boxApi.endpoints.getAllFiles.select();

const selectDataFileData = createSelector(selectDataFileResult, (dataFileResult) => dataFileResult.data);

export const {
  selectAll: selectAllDataFile,
  selectById: selectDataFileById,
  selectIds: selectDataFileid,
} = dataFilesAdapter.getSelectors((state: RootState) => selectDataFileData(state) ?? initialState);