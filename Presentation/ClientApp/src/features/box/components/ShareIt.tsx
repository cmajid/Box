import { useState } from "react";
import { DataFile } from "../boxApi";
import { BASE_URL } from "../../../store/api";
import { toast } from "react-hot-toast";
import FileIcon from "./FileIcon";

type Props = {
    file: DataFile;
    onSubmit: any;
}
const ShareIt = ({file, onSubmit}: Props)=>{
    const [currentTimeUnit, setCurrentTimeUnit] = useState('minutes');
    const [currentTime, setCurrentTime] = useState(10);
    const changeTimeUnit = (newTimeUnit: string) => {
        setCurrentTimeUnit(newTimeUnit)
    }
    const handleSubmit = (event)=>{
        event.preventDefault();
        switch(currentTimeUnit){
            case 'hours':{
                const timeInHours = currentTime * 60;
                return onSubmit(timeInHours);
            }
            case 'days':{
                const minutes = currentTime * 24 * 60;
                return onSubmit(minutes);
            }
        }
        return onSubmit(currentTime);
    }
    return (
        <div className="mr-2">
            <form onSubmit={handleSubmit}>
                <label 
                    htmlFor="times" 
                    className="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-2">
                 TIME unit:</label>
                <select 
                    id="times"
                    className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                    onChange={(event) => changeTimeUnit(event.target.value)}
                    value={currentTimeUnit}
                    >
                    <option value="minutes">Minutes</option>
                    <option value="hours">Hours</option>
                    <option value="days">Days</option>
                </select>
                <div className="flex flex-wrap -mx-3 mb-6 mt-2">
                    <div className="w-full px-3">
                    <label className="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-2" htmlFor="timer">
                        Time in {currentTimeUnit}:
                    </label>
                    <input 
                        className="appearance-none block w-full bg-gray-200 text-gray-700 border border-gray-200 rounded py-3 px-4 mb-3 leading-tight focus:outline-none focus:bg-white focus:border-gray-500" 
                        id="timer" 
                        value={currentTime}
                        type="number"
                        onChange={(e)=>{
                            setCurrentTime(+e.target.value);
                        }}/>
                    <p className="text-gray-600 text-xs italic">Share your world with your friends.</p>
                    </div>
                </div>
                <button className="bg-blue-500 shadow-lg hover:bg-blue-300 p-2 rounded text-white w-full">Share It</button>
                <hr className="my-4 mr-2"/>
                <p>
                <FileIcon extention={file.extention}  />
                        <span className="ml-2">
                            {file.name}     
                        </span>
                </p>
                <p 
                    onClick={() => {
                        navigator.clipboard.writeText(`${BASE_URL}/storage/share/${file.username}/${file.systemName}`);
                        toast.success("Share link copied to Clipboard!");
                    }}
                    className="cursor-pointer bg-orange-500 hover:bg-orange-300 w-full p-2 text-center my-2 text-white" 
                    >
                        Copy to clipboard!
                    </p>
            </form>
        </div>
    )
}

export default ShareIt;