import React from 'react'
import Header from '../IntroComponents/Header'
import {Col,Row} from 'reactstrap'
import LogsInfo from './LogsInfo'
import FilterLogs from './FilterLogs'
import TableLogs from './TableLogs'
import {useState,useEffect} from 'react'
import {GetLogsFilterbyDate,GetLogsFilterbyStatus} from '../Requests/Requests' 
import ReactToExcel from 'react-html-table-to-excel'



export default function LogsPage(props) {


    const [Logs,setLogs] = useState({logs : [], LogCount : 0, ProjectKey : "", });
    const[DateValue,setDateValue] = useState(1000);
    const[StatusValue,setStatusValue] = useState(1000);


    //BUTTON SPINNERS
    const[UpdateButton,setUpdateButton] = useState(false);
    const[ProjectButton,setProjectButton] = useState(false);
    const[BugsButton,setBugsButton] = useState(false);

    //MODAL TOGGLE
    const[Show,setShow] = useState(false);
    const[DownloadExcel,setDownloadExcel] = useState(false);
    
    useEffect(()=>{   //DATE DEĞERİNE GÖRE REQUEST
        
        GetLogsFilterbyDate(DateValue)
        .then(response=>{
            setLogs(response.data);
        })
        .catch(error=>{
           props.history.push("/Error")
        })
    // eslint-disable-next-line react-hooks/exhaustive-deps
    },[DateValue])    //DATEVALUE HER DEĞİŞTİĞİNDE TETİKLEN


    useEffect(()=>{   //STATUS DEĞERİNE GÖRE REQUEST
        GetLogsFilterbyStatus(StatusValue)
        .then(response=>{
            setLogs(response.data)
        })
        .catch(error=>{
            props.history.push("/Error")
        })
    // eslint-disable-next-line react-hooks/exhaustive-deps
    },[StatusValue])  //STATUSVALUE HER DEĞİŞTİĞİNDE TETİKLEN


    const DateValueChange= (event)=>{
        const value = event.target.value;
        setDateValue((value));
    }

    const StatusValueChange = (event)=>{
        const value = event.target.value;

        setStatusValue(value);
    }


    const UpdateButtonclick = ()=>{
        setUpdateButton(true);

        setTimeout(()=>{
            setUpdateButton(true);
            props.history.push('/GetData');

        },1500)
    }

    const ProjectButtonclick = ()=>{
        setProjectButton(true);

        setTimeout(()=>{

            setProjectButton(false);
            props.history.push('/ProjectKey');

        },1500)
    }


    const BugsButtonClick = ()=>{

        setBugsButton(true);

        setTimeout(()=>{

            setBugsButton(false);
            props.history.push("/Issues");
        },1500)
    }

      

    return (
    
        <div>
            <Header />
            <div className="BugPage container-fluid bg-light">
             
                <LogsInfo ProjectKey={Logs.projectKey} LogCount={Logs.logCount}/>   
                <FilterLogs DateValueChange={DateValueChange} StatusValueChange={StatusValueChange}/>

                <Row className="my-1">
                    <Col md="1"></Col>
                    <Col md="10" className="text-right">

                        
                        <ReactToExcel 
                            className="btn btn-sm btn-outline-primary mr-2"
                            table="AllLogsTable"
                            filename = "Logs"
                            sheet="Logs"
                            buttonText="Excel"
                        />

                        <button  type="button" className="btn btn-sm btn-outline-primary raunded"
                        disabled={UpdateButton} onClick={UpdateButtonclick}>
                            {UpdateButton ? 
                            <span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"> </span>
                            :null
                           } Güncelle</button>

                        <button type="button" className="btn btn-sm btn-outline-primary ml-2 raunded"
                        disabled={ProjectButton} onClick={ProjectButtonclick}>
                            {ProjectButton ? 
                            <span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"> </span>
                            :null} Proje Değiştir</button>

                        <button type="button" className="btn btn-sm btn-outline-primary ml-2 raunded"
                        onClick={BugsButtonClick} disabled={BugsButton}>
                            {BugsButton ?
                            <span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"> </span>
                            :null } Tüm Buglar</button>

                    </Col>
                    <Col md="1"></Col>
                </Row>

                <Row className="mb-5">
                    <Col md="1"></Col>
                    <Col md="10">
                    <div className="d-flex bg-white align-items-center  rounded shadow-sm border border-primary">
                           <TableLogs Logs={Logs.logs}/>
                        </div>
                    </Col>
                    <Col md="1"></Col>
                </Row>
               
            </div>

           
        
      </div>         
        
    )
                 
}

