import React from 'react'

export default function Table(props) {

    const Click = (id)=>{
        alert(id)
    }
    const {Logs} = props;

    return (
        <table className="table table-sm table-hover">
            <thead>
            <th scope="col" className="text-center">Bug ID</th>
                <th scope="col" className="text-center">Author</th>
                <th scope="col" className="text-center">Created</th>
                <th scope="col" className="text-center">Field</th>
                <th scope="col" className="text-center">From</th>
                <th scope="col" className="text-center">To</th>
               
            
            </thead>
            <tbody>
                
            {Logs.map(log=>(
                     <tr>
                         <td className="text-center"><small>{log.bugID}</small></td>
                           <td className="text-center"><small>{log.author}</small></td>
                           <td className="text-center"><small>{log.created}</small></td>
                           <td className="text-center"><small>{log.field}</small></td>
                           <td className="text-center"><small>{log.fromString}</small></td>
                           <td className="text-center" ><small>{log.toString}</small></td>
                          
                           
                       </tr>
                   ))}
               
            </tbody>
        </table>
    )
}
