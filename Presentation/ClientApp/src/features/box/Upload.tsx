import axios from "axios";
import { AppStorage } from "../../assets/utilities/storage";
import { BASE_URL } from "../../store/api";
import { toast } from "react-hot-toast";
import { FileTypes } from "../../assets/utilities/fileTypes";
import { boxApi } from "./boxApi";
import { useDispatch } from "react-redux";

const Upload = ()=>{
    const dispatch = useDispatch();

    const uploadFile = async (e: any) => {
        for(var i=0; i<= e.target.files.length; i++){
            const formFile = e.target.files[i]
            const fileName = e.target.files[i].name;
            const fileExtention: string = fileName.split('.').pop();
            if(FileTypes.indexOf(fileExtention.toLowerCase()) < 0){
                toast.error("File type is not supported.")
                return;
            }
            const formData = new FormData();
            formData.append("formFile", formFile);
            formData.append("fileName",fileName );
            try {
                const config = {
                    headers: { Authorization: `Bearer ${AppStorage.Provider.getItem('token')}` }
                };
                await toast.promise(axios.post(`${BASE_URL}/storage`, formData, config), {
                    loading: 'Uploading',
                    success: 'Done!',
                    error: 'File was more than 50MB!',
                });
                dispatch(boxApi.util.resetApiState());
            } catch (ex) {
                console.log(ex);
            }
        }
    };

    return (
        <>
            <div className="flex items-center justify-center w-screen my-2">
                <label htmlFor="dropzone-file" className="flex flex-col items-center justify-center w-1/3 h-32 border-2 border-gray-300 border-dashed rounded-lg cursor-pointer bg-gray-50 dark:hover:bg-bray-200 dark:bg-gray-100 hover:bg-gray-100 dark:border-gray-600 dark:hover:border-gray-500 dark:hover:bg-gray-200">
                    <div className="flex flex-col items-center justify-center pt-5 pb-6">
                        <svg aria-hidden="true" className="w-10 h-10 mb-3 text-gray-400" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M7 16a4 4 0 01-.88-7.903A5 5 0 1115.9 6L16 6a5 5 0 011 9.9M15 13l-3-3m0 0l-3 3m3-3v12"></path></svg>
                        <p className="mb-2 text-sm text-gray-500 dark:text-gray-400"><span className="font-semibold">Click to upload</span> </p>
                        <p className="text-xs text-gray-500 dark:text-gray-400">PDF / Excel / Word/ txt/ pictures documents (MAX. 50Mb)</p>
                    </div>
                    <input 
                        multiple
                        onChange={uploadFile} 
                        id="dropzone-file" 
                        type="file" 
                        className="hidden" />
                </label>
            </div> 
        </>
  );
}

export default Upload;