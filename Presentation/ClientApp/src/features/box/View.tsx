import { useSelector } from "react-redux";
import { useNavigate, useParams } from "react-router-dom";
import { RootState } from "../../store";
import { selectDataFileById } from "./boxApi";

const View = ()=>{
    const { id } = useParams();
    const navigate = useNavigate();
    if(!id){
        navigate("/");
        return (<div>NOT FOUND</div>);
    }

    const file = useSelector((state: RootState)=> selectDataFileById(state, +id));
    if(!file){
        navigate("/");
        return (<div>NOT FOUND</div>);
    }

    return (<div>{file.name}</div>);
}

export default View;