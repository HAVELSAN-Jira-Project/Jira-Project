import React from 'react'
import {Row,Col} from 'reactstrap'
import FilterLogo from '../Filter2.png'

export default function Filters2() {
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
                        <select className="form-control-sm">
                                <option value="">Tarih</option>
                                <option value="1">Son 1 Gün</option>
                                <option value="7">Son 1 Hafta</option>
                                <option value="30">Son 1 Ay</option>
                                <option value="1000">Tümü</option>
                        </select>      
                        </div>
                    </Col>
                    <Col md="2">
                    <div className=" mr-3">
                        <h6 className="mr-5">Severity</h6>
                        <select className="form-control-sm">
                                <option value="">Severity</option>
                                <option value="1">1</option>
                                <option value="1">2</option>
                                <option value="2">3</option>
                                <option value="3">4</option>
                                <option value="4">5</option>
                                <option value="5">Tümü</option>
                        </select>      
                        </div>
                    </Col>
                    <Col md="5" className="ml">
                    <div className=" mr-3">
                        <h6 className="mr-5">Arama</h6>
                        <input type="text" className="form-control-sm" placeholder="Summary"></input>   

                        <button type="button" className="btn btn-sm btn-outline-primary ml-4 mb-1">Filtrele</button> 
                        </div>
                    </Col>
                    <Col md="2">    
                    </Col>
                    </div>
           </Col>
           <Col md="2"></Col>
       </Row>
            
    )
}
