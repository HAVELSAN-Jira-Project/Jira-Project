import React from 'react'

export default function Table(props) {

    const Click = (id)=>{
        alert(id)
    }
    const {Bugs} = props;

    return (
        <table className="table table-sm table-hover">
            <thead>
                <th scope="col" className="text-center">Bug ID</th>
                <th scope="col" className="text-center">Summary</th>
                <th scope="col" className="text-center">Creator</th>
                <th scope="col" className="text-center">Created</th>
                <th scope="col" className="text-center">Rebound</th>
                <th scope="col" className="text-center">Status</th>
                <th scope="col" className="text-center">Severity</th>
                <th scope="col" className="text-center">Log</th>
            
            </thead>
            <tbody>
                
            {Bugs.map(bug=>(
                     <tr>
                           <td className="text-center"><small>{bug.bugID}</small></td>
                           <td style={{width:"20%"}} className="text-center"><small>{bug.summary}</small></td>
                           <td className="text-center"><small>{bug.creator}</small></td>
                           <td className="text-center"><small>{bug.created}</small></td>
                           <td style={{width:"5%"}} className="text-center"><small>3</small></td>
                           <td className="text-center" ><small>{bug.status}</small></td>
                           <td  className="text-center"><small>{bug.severity? bug.severity: <small>-</small>}</small></td>
                           <td className="text-center">
                               <button type="button" className="btn btn-sm btn-outline-primary"
                               onClick={()=>Click(bug.created.substring(8,10))}>Log</button> 
                            </td>
                       </tr>
                   ))}
               
            </tbody>
        </table>
    )
}
