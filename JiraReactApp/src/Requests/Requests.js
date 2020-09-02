import axios from 'axios'

export const GetBugs = ()=>{ 
    
    return axios.get('https://localhost:44310/api/Bugs/GetBugs');
}

export const AddIssues = ()=>{

    return axios.get('https://localhost:44310/api/Issues/AddIssues'); 
}

export const ClearIssues = ()=>{

    return axios.get('https://localhost:44310/api/Issues/ClearIssues'); 
}

export const PostProjectKey = (body)=>{

    return axios.post('https://localhost:44310/api/Issues/ProjectKey',body); 
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



export const GetIssuesFilterbyDate = (day)=>{

    return axios.get('https://localhost:44310/api/Issues/GetIssuesFilterbyDate?days='+day); 
}



export const GetIssuesFilterbySeverity = (severity)=>{

    return axios.get('https://localhost:44310/api/Issues/GetIssuesFilterbySeverity?severity='+severity); 
}




export const GetSearchedIssues = (text)=>{

    return axios.get('https://localhost:44310/api/Issues/GetSearchedIssues?text='+text); 
}



export const GetLogsFilterbyDate = (day)=>{

    return axios.get('https://localhost:44310/api/Logs/GetLogsFilterbyDate?day='+day); 
}

export const GetLogsFilterbyStatus = (statuID)=>{

    return axios.get('https://localhost:44310/api/Logs/GetLogsFilterbyStatus?statusID='+statuID); 
}

export const GetLogsbyID = (bugID)=>{

    return axios.get('https://localhost:44310/api/Logs/GetLogsbyID?id='+bugID); 
}


export const ChangeIssue = (body)=>{
    return axios.post('https://localhost:44310/api/Issues/IssueType',body); 
}







