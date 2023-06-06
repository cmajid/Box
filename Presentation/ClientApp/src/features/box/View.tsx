import { useSelector } from "react-redux";
import { useNavigate, useParams } from "react-router-dom";
import { RootState } from "../../store";
import { selectDataFileById } from "./boxApi";

const View = ()=>{
    const { id } = useParams();
    const navigate = useNavigate();
    if(!id){
        navigate("/");
        return;
    }

    const file = useSelector((state: RootState)=> selectDataFileById(state, +id));
    if(!file){
        navigate("/");
        return;
    }

    return (<div>{file.name}</div>);
}

export default View;