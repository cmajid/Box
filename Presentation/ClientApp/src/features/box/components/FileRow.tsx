import { EntityId } from "@reduxjs/toolkit";
import { useSelector } from "react-redux";
import { Link } from "react-router-dom";
import { selectDataFileById, useDeleteFileMutation } from "../boxApi";
import { RootState } from "../../../store";
import FileIcon from "./FileIcon";

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
    return (
        <tr className="border-b dark:border-neutral-500">
            <td className="whitespace-nowrap px-6 py-4 text-left">
                <FileIcon extention={file.extention} />
                <span className="ml-2">{file?.name}</span>
            </td>
            <td className="whitespace-nowrap px-6 py-4">{new Date(file.createdDatetime).toLocaleString()}</td>
            <td className="whitespace-nowrap px-6 py-4">{file?.size}Kb</td>
            <td className="whitespace-nowrap px-6 py-4 text-right">
                <Link to={`/box/view/${file.id}`} className="bg-blue-500 p-3 text-white rounded"> Share</Link>
                <Link to="/" className="bg-green-500 p-3 ml-1 text-white rounded">Download</Link>
                <a onClick={handleDelete} className="bg-orange-500 p-3 ml-1 text-white rounded cursor-pointer">Delete</a>
            </td>
        </tr>
    )
}

export default FileRow;