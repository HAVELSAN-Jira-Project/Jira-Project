import React from 'react'
import log from '../log.png'
import {Row,Col} from 'reactstrap'

export default function LogDetailsInfo(props) {
   const{BugID,LogCount} = props;
    return (
        
            <Row>
                <Col md="1"></Col>
                <Col md="10">
                
                    <div className="d-flex bg-white align-items-center p-3 my-1 mt-5 rounded shadow-sm border border-primary">
                    <img src={log} width={60} height={60} className=" mr-4 img-fluid" alt="Info" />
                    <div className="lh-100">
                    <h5>{BugID} Numaralı Issue</h5>
                    <small style={{marginLeft:"2px"}}>Toplamda <b>{LogCount}</b> Log</small>
                    </div>
                    </div>

                </Col>
                <Col md="1"></Col>
            </Row>
    )
}
