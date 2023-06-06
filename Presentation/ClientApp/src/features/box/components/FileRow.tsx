import { EntityId } from "@reduxjs/toolkit";
import { ImFilePdf } from "react-icons/im";
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
            <td className="whitespace-nowrap w-2 px-6  py-4">
                <input type="checkbox" name="select" />
            </td>
            <td className="whitespace-nowrap px-6 py-4 text-left">
                <FileIcon extention={file.extention} />
                <span className="ml-2">{file?.name}</span>
            </td>
            <td className="whitespace-nowrap px-6 py-4">{new Date(file.createdDatetime).toLocaleString()}</td>
            <td className="whitespace-nowrap px-6 py-4">{file?.size}Kb</td>
            <td className="whitespace-nowrap px-6 py-4">
                <Link to={`/box/view/${file.id}`} className="bg-blue-500 p-3 text-white">View</Link>
                <Link to="/" className="bg-green-500 p-3 ml-1 text-white">Download</Link>
                <button onClick={handleDelete} className="bg-orange-500 p-3 ml-1 text-white">Delete</button>
            </td>
        </tr>
    )
}

export default FileRow;