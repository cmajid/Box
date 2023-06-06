import { ImFileExcel, ImFilePdf, ImFileText2, ImFileWord, ImImage, ImQuestion } from "react-icons/im"

type Props = {
    extention : string;
}
const FileIcon = ({ extention }: Props)=>{

    switch (extention){
        case '.pdf':
            return <ImFilePdf className="inline "/> ;
        case '.jpg':
        case '.png':
        case '.jpeg':
            return <ImImage className="inline "/> ;
        case '.xlsx':
        case '.xls':
        case '.xlsm':
            return <ImFileExcel className="inline "/> ;
        case '.doc':
        case '.docs':
            return <ImFileWord className="inline "/> ;
        case '.txt':
            return <ImFileText2 className="inline "/> ;
    }

    return <ImQuestion className="inline "/> ;
}

export default FileIcon;