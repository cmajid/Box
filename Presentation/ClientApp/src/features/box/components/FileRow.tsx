import { EntityId } from "@reduxjs/toolkit";
import { useSelector } from "react-redux";
import { Link } from "react-router-dom";
import { selectDataFileById, useDeleteFileMutation } from "../boxApi";
import { RootState } from "../../../store";
import FileIcon from "./FileIcon";
import { BASE_URL } from "../../../store/api";
import toast from "react-hot-toast";
import ShareIt from "./ShareIt";

type Props = {
    id : EntityId;
}
const FileRow = ({ id }: Props)=>{
    const [deleteFile] = useDeleteFileMutation();
    const file = useSelector((state: RootState)=> selectDataFileById(state, id));
    if(!file)
        return null;

    const handleDelete = ()=>{
        deleteFile(file.id);
    }
    const handleShareSubmit = (shareTime: number)=>{
        console.log(shareTime);
        toast.success("You Share it With ")
    }

    const handleShare = ()=>{
        toast((t)=> 
            <>
                <ShareIt file={file} onSubmit={handleShareSubmit} />
                <div className="flex border-l border-gray-200">
                    <button
                        onClick={() => toast.dismiss(t.id)}
                        className="w-full border border-transparent rounded-none rounded-r-lg p-4 flex items-center justify-center text-sm font-medium text-indigo-600 hover:text-indigo-500 focus:outline-none focus:ring-2 focus:ring-indigo-500"
                    >
                        Close
                    </button>
                </div>
            </>,{duration:30*1000})
    }

    return (
        <tr className="border-b dark:border-neutral-500">
            <td className="whitespace-nowrap px-6 py-4 text-left">
                <FileIcon extention={file.extention} />
                <span className="ml-2">{file?.name}</span>
            </td>
            <td className="whitespace-nowrap px-6 py-4">{new Date(file.createdDatetime).toLocaleString()}</td>
            <td className="whitespace-nowrap px-6 py-4">{file?.size}MB</td>
            <td className="whitespace-nowrap px-6 py-4 text-right">
                <a onClick={handleShare} className="bg-blue-500 p-3 text-white rounded cursor-pointer"> Share</a>
                <Link 
                    to={`${BASE_URL}/storage/${file.username}/${file.systemName}`} 
                    className="bg-green-500 p-3 ml-1 text-white rounded"
                    onClick={()=>toast.success(file.name)}
                    >Download</Link>
                <a onClick={handleDelete} className="bg-orange-500 p-3 ml-1 text-white rounded cursor-pointer">Delete</a>
          
            </td>
        </tr>
    )
}

export default FileRow;