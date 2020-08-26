import React from 'react'
import Header from '../IntroComponents/Header'
import Info from './Info'
import Filters2 from '../BugsPageComponents/Filters2'
import {Row,Col} from 'reactstrap'
import {useState,useEffect} from 'react'
import Table from './Table'
import {GetBugs} from '../Requests/Requests'
export default function MainPage(props) {

    const [Bugs,setBugs] = useState({bugs : [], BugCount : 0, ProjectKey : ""});
    const[BugsControl,setBugsControl] = useState(false);

    useEffect(()=>{
        if(!BugsControl){
            GetBugs()
            .then(response=>{
                setBugs(response.data);
                setBugsControl(true);
            })
            .catch(error=>{
                props.history.push("/Not-Found")
            })
        }
       
    })
    return (
        <div>
            <Header />
            <div className="BugPage container-fluid bg-light">
                
                <Info  BugCount = {Bugs.bugCount} ProjectKey = {Bugs.projectKey} />   
                <Filters2 />
                <Row className="my-1">
                    <Col md="2"></Col>
                    <Col md="8" className="text-right">
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
                    {/* <Col md="2"></Col> */}
                    <Col md="12">
                        <div className="d-flex bg-white align-items-center  rounded shadow-sm border border-primary">
                           <Table Bugs={Bugs.bugs} />
                        </div>
                    </Col>
                    {/* <Col md="2"></Col> */}
                </Row>


               
            </div>
            
        </div>
    )
}
