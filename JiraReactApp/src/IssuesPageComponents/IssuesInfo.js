import React from 'react'
import Issues from '../Detail.png'
import Bugs from '../Bugs.png'
import Tasks from '../Tasks.png'
import Stories from '../Stories.png'
import Epics from '../Epics.png'
import {Row,Col} from 'reactstrap'

export default function IssuesInfo(props) {
   const{ProjectKey,BugCount,IssueTypeChange,IssueTypeID} = props;
   const Icons = [Issues,Bugs,Tasks,Stories,Epics];
    return (
        
            <Row>
                <Col md="1"></Col>
                <Col md="10">
                
                    <div className="d-flex bg-white align-items-center p-3 my-1 mt-5 rounded shadow-sm border border-primary">
                    <img src={Icons[IssueTypeID]} width={60} height={60} className=" mr-4 img-fluid" alt="Info" />
                    <div className="lh-100">
                    <h5>{ProjectKey} Projesi</h5>
                    <small style={{marginLeft:"2px"}}>Toplamda <b>{BugCount} Kayıt</b> </small>
                    </div>
                    <div className=" my-1 mt-2 lh-100" style={{marginLeft:"100px"}}>
                    <h5>Issue Türü</h5>
                    <select className="form-control-sm" onChange={IssueTypeChange}>
                        <option value="0">Tümü</option>
                        <option value="1">Bug</option>
                        <option value="2">Task</option>
                        <option value="3">Story</option>
                        <option value="4">Epic</option>
                    </select>
                    </div>
                    </div>
                </Col>
                <Col md="1"></Col>
            </Row>
    )
}
