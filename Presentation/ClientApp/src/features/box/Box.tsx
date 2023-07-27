import { useGetAllFilesQuery } from "./boxApi";
import ErrorHandler from "../../components/ErrorHandler";
import { FetchBaseQueryError } from "@reduxjs/toolkit/dist/query";
import FileRow from "./components/FileRow";
import { EntityId } from "@reduxjs/toolkit";
import Upload from "./Upload";

const Box = ()=> {
    const { data : files, isError , error } = useGetAllFilesQuery();
    if(isError)
      return (<ErrorHandler error={error as FetchBaseQueryError} />)

    return (
        <div className="flex-col flex items-center justify-center">
          <Upload />
          <div className="w-full overflow-x-auto sm:-mx-6 lg:-mx-8">
            <div className="inline-block min-w-full py-2 sm:px-6 lg:px-8">
              <div className="overflow-hidden">
                <table className="min-w-full text-center text-sm font-light">
                  <thead
                    className="border-b bg-neutral-500 font-medium text-white dark:border-neutral-500 dark:bg-neutral-900">
                    <tr >
                      <th scope="col" className="px-6 py-4 text-left">Name</th>
                      <th scope="col" className="px-6 py-4">Upload Time</th>
                      <th scope="col" className="px-6 py-4">Size</th>
                      <th scope="col" className="px-6 py-4">Downloads</th>
                      <th scope="col" className="px-6 py-4">Status</th>
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