import React from 'react'
import Header from '../IntroComponents/Header'
import Info from './Info'
import Filters2 from '../BugsPageComponents/Filters2'
import {Row,Col} from 'reactstrap'
import {useState,useEffect} from 'react'
import Table from './Table'
import {GetBugsFilterbyDate,GetBugsFilterbySeverity,GetSearchedBugs} from '../Requests/Requests'
export default function MainPage(props) {

    const [Bugs,setBugs] = useState({bugs : [], BugCount : 0, ProjectKey : "", totalRebound : 0});
    const[DateValue,setDateValue] = useState(1000);
    const[SeverityValue,setSeverityValue] = useState(1000);
    const[Searchtext,setSearchText] = useState(null);

    
    useEffect(()=>{  //TARİH DEĞİŞTİĞİNDE STATE'E SETLE,REQEUST AT.DÖNEN LİSETYİ BUGSA SETLE. 
                     //BUGS İÇERİĞİ DEĞİŞTİĞİNDE, COMPONENT YENİDEN RENDER EDİLİR.
                     
        GetBugsFilterbyDate(DateValue)
        .then(response=>{
            setBugs(response.data)
        })
        .catch(error=>{
            props.history.push("/Not-Found")
        })
    },[DateValue])  //TARİH DEĞİŞTİĞİ ANDA TETİKLEN


    useEffect(()=>{  //SEVERİTY DEĞİŞTİĞİNDE STATE'E SETLE,REQEUST AT.DÖNEN LİSETYİ BUGSA SETLE. 
                     //BUGS İÇERİĞİ DEĞİŞTİĞİNDE, COMPONENT YENİDEN RENDER EDİLİR.

        GetBugsFilterbySeverity(SeverityValue)
        .then(response=>{
            setBugs(response.data)
        })
        .catch(error=>{
            props.history.push("/Not-Found")
        })
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
            props.history.push("/Not-Found")
        })
    }
    return (
        <div>
            <Header />
            <div className="BugPage container-fluid bg-light">
                
                <Info  BugCount = {Bugs.bugCount} ProjectKey = {Bugs.projectKey} />   
                <Filters2 SearchInputChange={SearchInputChange} SearchButtonClick={SearchButtonClick}  
                DateChange = {DateChange} SeverityChange={SeverityChange}/>

                <Row className="my-1">
                    <Col md="2"></Col>
                    <Col md="2">
                        <small>Totalde <b>{Bugs.totalRebound}</b> Rebound</small>
                    </Col>
                    <Col md="6" className="text-right">
                        <button type="button" className="btn btn-sm btn-outline-primary raunded">
                        Güncelle</button>

                        <button type="button" className="btn btn-sm btn-outline-primary ml-2 raunded">
                        Proje Değiştir</button>

                        <button type="button" className="btn btn-sm btn-outline-primary ml-2 raunded">
                        Tüm Loglar</button>

                    </Col>
                    <Col md="2"></Col>
                </Row>

                <Row className="mb-4">
                    <Col md="2"></Col>
                    <Col md="8">
                        <div className="d-flex bg-white align-items-center  rounded shadow-sm border border-primary">
                           <Table Bugs={Bugs.bugs} />
                        </div>
                    </Col>
                    <Col md="2"></Col>
                </Row>
            </div>          
        </div>
    )
}
