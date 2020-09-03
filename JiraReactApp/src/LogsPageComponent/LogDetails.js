import React from 'react'
import Header from '../IntroComponents/Header'
import {Col,Row} from 'reactstrap'
import TableLogDetail from './TableLogDetail'
import LogDetailsInfo from './LogDetailsInfo'
import {GetLogsbyID} from '../Requests/Requests'
import {useState,useEffect} from 'react'
import ReactToExcel from 'react-html-table-to-excel'

export default function LogDetails(props) {

    const [Logs,setLogs] = useState({logs : [], LogCount : 0, ProjectKey : "", });
    const [SendRequest,setSendRequest] = useState(true)
    

    const {BugID} = props.location.state;


    useEffect(()=>{      
        if(SendRequest){
            setSendRequest(false);
            GetLogsbyID(BugID)
            .then(response=>{
                setLogs(response.data)
            })
            .catch(error=>{
                props.history.push("/Error")
            })
        }
        
    })

    return (
        <div>
            <Header />
            <div className="BugPage container-fluid bg-light">

            <LogDetailsInfo LogCount={Logs.logCount} BugID={BugID}  />
            <Row className="mt-3">
                    <Col md="1"></Col>
                    <Col md="10" className="text-right">

                    <ReactToExcel 
                            className="btn btn-sm btn-outline-primary"
                            table="SelectedLog"
                            filename = "SelectedLogDetails"
                            sheet="Logs"
                            buttonText="Excel"/>   

                    </Col>
                    <Col md="1"></Col>
                </Row>
            <Row className="mb-5">
                    <Col md="1"></Col>
                    <Col md="10">
                        <div className="d-flex mt-1 bg-white align-items-center rounded shadow-sm border border-primary">
                            
                           <TableLogDetail Logs={Logs.logs}/>
                        </div>
                    </Col>
                    <Col md="1"></Col>
                </Row>

            </div>
        </div>
    )
}

