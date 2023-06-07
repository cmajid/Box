import { useGetAllFilesQuery } from "./boxApi";
import ErrorHandler from "../../components/ErrorHandler";
import { FetchBaseQueryError } from "@reduxjs/toolkit/dist/query";
import FileRow from "./components/FileRow";
import { EntityId } from "@reduxjs/toolkit";
import Upload from "./Upload";

const Box = ()=> {
    const { data : files, isLoading, isError , error } = useGetAllFilesQuery();
    if(isLoading)
      return (<div>Loading...</div>)

    if(isError)
      return (<ErrorHandler error={error as FetchBaseQueryError} />)

    return (
        <div className="flex-col flex items-center justify-center">
          <Upload />
          <div className="w-4/5 overflow-x-auto sm:-mx-6 lg:-mx-8">
            <div className="inline-block min-w-full py-2 sm:px-6 lg:px-8">
              <div className="overflow-hidden">
                <table className="min-w-full text-center text-sm font-light">
                  <thead
                    className="border-b bg-neutral-800 font-medium text-white dark:border-neutral-500 dark:bg-neutral-900">
                    <tr>
                      <th scope="col" className="px-6 py-4 text-left">Name</th>
                      <th scope="col" className="px-6 py-4">Upload Time</th>
                      <th scope="col" className="px-6 py-4">Number Of Downloads</th>
                      <th scope="col" className="px-6 py-4">Action</th>
                    </tr>
                  </thead>
                  <tbody>
                    {files?.ids.map((id: EntityId)=>{
                      return <FileRow key={+id} id={id} />
                    })}
                  </tbody>
                </table>
              </div>
            </div>
          </div>
        </div>
    )
}

export default Box;