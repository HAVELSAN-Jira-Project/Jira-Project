import React from 'react'
import Header from '../IntroComponents/Header'
import BugInfo from './BugInfo'
import FilterBugs from './FilterBugs'
import {Row,Col} from 'reactstrap'
import {useState,useEffect} from 'react'
import Table from './Table'
import {GetBugsFilterbyDate,GetBugsFilterbySeverity,GetSearchedBugs} from '../Requests/Requests'
import ReactToExcel from 'react-html-table-to-excel'


export default function MainPage(props) {

    const [Bugs,setBugs] = useState({bugs : [], BugCount : 0, ProjectKey : "", totalRebound : 0});
    const[DateValue,setDateValue] = useState(1000);
    const[SeverityValue,setSeverityValue] = useState(1000);
    const[Searchtext,setSearchText] = useState(null);


    //BUTTON SPINNERS
    const[UpdateButtonDisable,setUpdateButton] = useState(false);
    const[ChangeProjectDisable,setChangeProjectButton] = useState(false);
    const[LogsButtonDisable,setLogsButton] = useState(false);
    const[LogDetailButtonDisable,setLogDetailButton] = useState(false);
    

    
    useEffect(()=>{  //TARİH DEĞİŞTİĞİNDE STATE'E SETLE,REQEUST AT.DÖNEN LİSETYİ BUGSA SETLE. 
                     //BUGS İÇERİĞİ DEĞİŞTİĞİNDE, COMPONENT YENİDEN RENDER EDİLİR.
                     
        GetBugsFilterbyDate(DateValue)
        .then(response=>{
            setBugs(response.data)
        })
        .catch(error=>{
            props.history.push("/Error")
        })
    // eslint-disable-next-line react-hooks/exhaustive-deps
    },[DateValue])  //TARİH DEĞİŞTİĞİ ANDA TETİKLEN


    useEffect(()=>{  //SEVERİTY DEĞİŞTİĞİNDE STATE'E SETLE,REQEUST AT.DÖNEN LİSETYİ BUGSA SETLE. 
                     //BUGS İÇERİĞİ DEĞİŞTİĞİNDE, COMPONENT YENİDEN RENDER EDİLİR.

        GetBugsFilterbySeverity(SeverityValue)
        .then(response=>{
            setBugs(response.data)
        })
        .catch(error=>{
            props.history.push("/Error")
        })
    // eslint-disable-next-line react-hooks/exhaustive-deps
    },[SeverityValue])  //SEVERİTY DEĞİŞTİĞİ ANDA TETİKLEN


    const DateChange = (event)=>{ 
        
         const value = parseInt(event.target.value);
         setDateValue((value));  //GELEN VERİYİ STATE'E SETLE 
    }

    const SeverityChange = (event)=>{
        const value = parseInt(event.target.value);
        setSeverityValue(value);
    }

    const SearchInputChange = (event)=>{ //INPUTU STATE'E SETLE, BUTONA TIKLANDIĞINDA STATE'DEN AL
        const value = event.target.value;
        setSearchText(value);
    }

    const SearchButtonClick = ()=>{  //BUTONA TIKLANDIĞINDA REQUEST AT
        GetSearchedBugs(Searchtext)
        .then(response=>{
            setBugs(response.data)
        })
        .catch(error=>{
            props.history.push("/Error")
        })
    }

    const UpdateButtonClick = () =>{  //UPDATE ROUTE
        setUpdateButton(true);

        setTimeout(() => {
            setUpdateButton(false);
            props.history.push('/GetData')
            }, 1500);
    }

    const ChangeProjectButtonClick = () =>{  //CHANGE PROJECT ROUTE
        setChangeProjectButton(true);

        setTimeout(() => {
            setChangeProjectButton(false);
            props.history.push('/ProjectKey')
            }, 1500);
    }

    const LogsPageButtonClick = () =>{  //CHANGE PROJECT ROUTE
        setLogsButton(true);

        setTimeout(() => {
            setLogsButton(false);
            props.history.push('/Logs')
            }, 1500);
    }


   const LogButtonClick = (id)=>{    //LOG BUTONUNA TIKLANDIĞINDA
    setLogDetailButton(true);
    const value = id;

       setTimeout(()=>{
        setLogDetailButton(false);

        props.history.push({
            pathname:"/LogDetails",
            state:{
                BugID: value
             }
           });
       },250)
    
   }
    
    return (
        <div>
            <Header />
            <div className="BugPage container-fluid bg-light">
                
                <BugInfo  BugCount = {Bugs.bugCount} ProjectKey = {Bugs.projectKey} />   
                <FilterBugs SearchInputChange={SearchInputChange} SearchButtonClick={SearchButtonClick}  
                DateChange = {DateChange} SeverityChange={SeverityChange}/>

                <Row className="my-1">
                    <Col md="2"></Col>
                    <Col md="2">
                        <small>Totalde <b>{Bugs.totalRebound}</b> Rebound</small>
                    </Col>
                    <Col md="6" className="text-right">

                    <ReactToExcel 
                            className="btn btn-sm btn-outline-primary mr-2"
                            table="AllBugsTable"
                            filename = "Bugs"
                            sheet="Logs"
                            buttonText="Excel"/>
                  

                        <button disabled={UpdateButtonDisable} onClick={()=>UpdateButtonClick()} 
                        type="button" className="btn btn-sm btn-outline-primary raunded">
                        {UpdateButtonDisable? 
                        <span class="spinner-border spinner-border-sm" role="status" aria-hidden="true">
                        </span>:null} Güncelle</button>

                        <button type="button" onClick={()=>ChangeProjectButtonClick()} className="btn btn-sm btn-outline-primary ml-2 raunded">
                        {ChangeProjectDisable? 
                        <span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>
                        :null}  Proje Değiştir</button>

                        <button onClick={()=>LogsPageButtonClick()} type="button" className="btn btn-sm btn-outline-primary ml-2 raunded">
                        {LogsButtonDisable ?
                        <span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>
                        :null} Tüm Loglar</button>

                    </Col>
                    <Col md="2"></Col>
                </Row>

                <Row className="mb-5">
                    <Col md="2"></Col>
                    <Col md="8">
                        <div className="d-flex bg-white align-items-center  rounded shadow-sm border border-primary">

                           <Table Bugs={Bugs.bugs} LogButtonClick={LogButtonClick} LogDetailButtonDisable={LogDetailButtonDisable} />

                        </div>
                    </Col>
                    <Col md="2"></Col>
                </Row>
            </div>          
        </div>
    )
}
