import React from 'react'
import {Row,Col} from 'reactstrap'
import FilterLogo from '../Filter2.png'

export default function FilterLogs(props) {
    
    const{DateValueChange,StatusValueChange} = props;
    return (
       <Row>
           <Col md="2"></Col>
           <Col md="8">
           <div className="d-flex bg-white align-items-center p-3 my-3 rounded shadow-sm border border-primary">
                    <img src={FilterLogo} width={60} height={60} className=" mr-4 img-fluid" alt="Info" />
                    <h5>Filtrele</h5>
                    <Col md="3">
                        <div className="ml-5">
                        <h6 className="mr-5">Tarih</h6>
                        <select className="form-control-sm" onChange={DateValueChange}>
                                <option value="1000">Tümü</option>
                                <option value="1">Son 1 Gün</option>
                                <option value="7">Son 1 Hafta</option>
                                <option value="30">Son 1 Ay</option>
                                <option value="365">Son 1 Yıl</option> 
                        </select>      
                        </div>
                    </Col>
                    <Col md="2">
                    <div className=" mr-3">
                        <h6 className="mr-5">Statü</h6>
                        <select className="form-control-sm" onChange={StatusValueChange}>
                                <option value="1000">Tümü</option>
                                <option value="1">To Do == In Progress</option>
                                <option value="2">To Do == Done</option>
                                <option value="3">In Progress == To Do</option>
                                <option value="4">In Progress == Done</option>
                                <option value="5">Done == To Do</option>
                                <option value="6">Done == In Progress</option>
                                
                        </select>      
                        </div>
                    </Col>
                    <Col md="5" className="ml">
                    
                    </Col>
                    <Col md="2"></Col>     
                    </div>
           </Col>
           <Col md="2"></Col>
       </Row>
            
    )
}
