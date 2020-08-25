import axios from 'axios'

export const GetBugs = ()=>{ 
    
    return axios.get('https://localhost:44310/api/Bugs/GetBugs');
}

export const AddBugs = ()=>{

    return axios.get('https://localhost:44310/api/Bugs/AddBugs'); 
}

export const ClearBugs = ()=>{

    return axios.get('https://localhost:44310/api/Bugs/ClearBugs'); 
}

export const PostProjectKey = (body)=>{

    return axios.post('https://localhost:44310/api/Bugs/ProjectKey',body); 
}

export const GetLogs = (body)=>{

    return axios.get('https://localhost:44310/api/Logs/GetLogs'); 
}

export const AddLogs = ()=>{

    return axios.get('https://localhost:44310/api/Logs/AddLogs'); 
}

export const ClearLogs = ()=>{

    return axios.get('https://localhost:44310/api/Logs/ClearLogs'); 
}