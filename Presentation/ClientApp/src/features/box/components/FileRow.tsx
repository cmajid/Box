import { EntityId } from "@reduxjs/toolkit";
import { useDispatch, useSelector } from "react-redux";
import { STORAGE_URL, boxApi, selectDataFileById, useDeleteFileMutation ,useShareFileMutation } from "../boxApi";
import { RootState } from "../../../store";
import FileIcon from "./FileIcon";
import toast from "react-hot-toast";
import ShareIt from "./ShareIt";
import { BASE_URL } from "../../../store/api";
import { axiosDownloadFile } from "../../../assets/utilities/axiosHelper";

type Props = {
    id : EntityId;
}
const FileRow = ({ id }: Props)=>{
    const dispatch = useDispatch();
    const [deleteFile] = useDeleteFileMutation();
    const [share] = useShareFileMutation();
    const file = useSelector((state: RootState)=> selectDataFileById(state, id));
    if(!file)
        return null;

    const handleDelete = ()=>{
        deleteFile(file.id);
    }
    const handleShareSubmit = (shareTime: number)=>{
        share({
            id: file.id , 
            time: shareTime
        });
        toast.success("You Share it With ")
    }
    const handleShare = ()=>{
        toast((t)=> 
            <div className="table-column">
                <div className="w-80">
                    <ShareIt file={file} onSubmit={handleShareSubmit} />
                    <div className="flex border-gray-200">
                        <a
                            onClick={() => toast.dismiss(t.id)}
                            className="cursor-pointer w-full border border-transparent rounded-none rounded-r-lg p-4 flex items-center justify-center text-sm font-medium text-indigo-600 hover:text-indigo-500 focus:outline-none focus:ring-2 focus:ring-indigo-500"
                        >
                            Close
                        </a>
                    </div>
                </div>
            </div>,{duration:30*1000})
    }
    const handleDownload = ()=>{
        axiosDownloadFile(`${BASE_URL}${STORAGE_URL}/${file.username}/${file.systemName}`,file.name )
        dispatch(boxApi.util.resetApiState());
    }
    return (
        <tr className="border-b dark:border-neutral-500">
            <td className="whitespace-nowrap px-6 py-4 text-left">
                <FileIcon extention={file.extention} />
                <span className="ml-2">{file?.name}</span>
            </td>
            <td className="whitespace-nowrap px-6 py-4">{new Date(file.createdDatetime).toLocaleString()}</td>
            <td className="whitespace-nowrap px-6 py-4">{file?.size}MB</td>
            <td className="whitespace-nowrap px-6 py-4">{file?.downloadCount}</td>
            <td className="whitespace-nowrap px-6 py-4">{file?.sharedDescription}</td>
            <td className="whitespace-nowrap px-6 py-4 text-right">
                <button onClick={handleShare} className="bg-blue-500 hover:bg-blue-300 p-3 text-white rounded"> Share</button>
                <button onClick={handleDownload} className="bg-green-500 hover:bg-green-300 p-3 ml-1 text-white rounded" >Download</button>
                <button onClick={handleDelete} className="bg-orange-500 hover:bg-orange-300 p-3 ml-1 text-white rounded">Delete</button>
            </td>
        </tr>
    )
}

export default FileRow;