import React from 'react'

export default function Table(props) {

    
    const {Bugs,LogButtonClick} = props;

    return (
        <table className="table table-sm table-hover" id="AllBugsTable">
            <thead>
                <th scope="col" className="text-center">Issue ID</th>
                <th scope="col" className="text-center">Summary</th>
                <th scope="col" className="text-center">Type</th>
                <th scope="col" className="text-center">Creator</th>
                <th scope="col" className="text-center">Rebound</th>
                <th scope="col" className="text-center">Status</th>
                <th scope="col" className="text-center">Severity</th>
                <th scope="col" className="text-center">Log</th>
            
            </thead>
            <tbody>
                
            {Bugs.map(bug=>(
                     <tr>
                           <td className="text-center"><small>{bug.issueID}</small></td>
                           <td style={{width:"20%"}} className="text-center"><small>{bug.summary}</small></td>
                           <td className="text-center"><small>{bug.type}</small></td>
                           <td className="text-center"><small>{bug.creator}</small></td>
                           
                           <td style={{width:"2%"}} className="text-center"><small>{bug.rebound}</small></td>
                           <td className="text-center" ><small>{bug.status}</small></td>
                           <td style={{width:"2%"}}  className="text-center"><small>{bug.severity? bug.severity: <small>-</small>}</small></td>
                           <td className="text-center">
                               <button type="button" className="btn btn-sm btn-outline-primary"
                                onClick={()=>LogButtonClick(bug.issueID)}> Log</button>     
                           </td>
                       </tr>
                   ))}
               
            </tbody>
        </table>
    )
}
