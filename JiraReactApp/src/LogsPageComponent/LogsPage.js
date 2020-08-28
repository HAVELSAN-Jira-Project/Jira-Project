import React from 'react'
import Header from '../IntroComponents/Header'
import {Col,Row} from 'reactstrap'
import LogsInfo from './LogsInfo'
import FilterLogs from './FilterLogs'
import TableLogs from './TableLogs'
import {useState,useEffect} from 'react'
import {GetLogsFilterbyDate} from '../Requests/Requests' 

export default function LogsPage(props) {


    const [Logs,setLogs] = useState({logs : [], LogCount : 0, ProjectKey : "", });
    const[DateValue,setDateValue] = useState(1000);


    useEffect(()=>{   //DATE DEĞERİNE GÖRE REQUEST

        GetLogsFilterbyDate(DateValue)
        .then(response=>{
            setLogs(response.data);
        })
        .catch(error=>{
           props.history.push("/Error")
        })
    },[DateValue])    //DATEVALUE HER DEĞİŞTİĞİNDE TETİKLEN


    const DateValueChange= (event)=>{
        const value = event.target.value;
        setDateValue((value));
    }


    return (
    
        <div>
            <Header />
            <div className="BugPage container-fluid bg-light">
                
                <LogsInfo ProjectKey={Logs.projectKey} LogCount={Logs.logCount}/>   
                <FilterLogs DateValueChange={DateValueChange} />

                <Row className="my-1">
                    <Col md="2"></Col>
                    <Col md="8" className="text-right">

                        <button  type="button" className="btn btn-sm btn-outline-primary raunded">Güncelle</button>

                        <button type="button"  className="btn btn-sm btn-outline-primary ml-2 raunded"> Proje Değiştir</button>

                        <button type="button" className="btn btn-sm btn-outline-primary ml-2 raunded"> Tüm Buglar</button>

                    </Col>
                    <Col md="2"></Col>
                </Row>

                <Row className="mb-4">
                    <Col md="2"></Col>
                    <Col md="8">
                        <div className="d-flex bg-white align-items-center  rounded shadow-sm border border-primary">
                           <TableLogs Logs={Logs.logs}/>
                        </div>
                    </Col>
                    <Col md="2"></Col>
                </Row>
            </div> </div>         
        
    )
                 
}

