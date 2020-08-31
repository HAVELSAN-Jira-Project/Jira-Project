import React, { Component } from 'react'
import Header from '../IntroComponents/Header'
import {PostProjectKey} from '../Requests/Requests'
import swal from 'sweetalert';


export default class ProjectPage extends Component {

    state={
        ProjectKey : null,
        PendingApi : false,
        ErrorResponse : null,
        Validation : {}
        
    }

    InputChange = (event)=>{
        const name = event.target.name;
        const value = event.target.value;
       const validation = this.state.Validation;
       validation[name] = undefined;

        this.setState({
            [name] : value,
            Validation : validation
            
            
        })
    }

    SaveProjectKey = ()=>{
        
        const body = {ProjectKey : this.state.ProjectKey}
        this.setState({PendingApi:true})

        PostProjectKey(body)
        .then(response=>{  //SUCCESS
            
            return response.data

        })
        .then(data=>{
              
              setTimeout(() => {
                
                this.props.history.push('/GetData');
                this.setState({PendingApi:false})
                }, 1500);
        })
        
        .catch(error=>{
            this.setState({PendingApi:false})

            error.response.data.errors ? 
            this.setState({Validation:error.response.data.errors}) 
            : this.setState({ErrorResponse:error.response.data})
        })
    }


    render() {
        const {Validation} = this.state;
        return (
            <div>
                <Header />
                <div className="container-fluid bg-light">
                <div className="IntroPage position-relative overflow-hidden p-3 text-center bg-light">
                <div className="col-md-5 p-lg-5 mx-auto my-5">
                    <h3>Lütfen Proje Numaranızı Girin</h3>
                    <form>
                        <div className="form-group">
                            <input style={{width:"79%"}} name="ProjectKey" type="text" onChange={this.InputChange} className={
                                Validation.ProjectKey ? "form-control is-invalid mt-4 ml-5" : "form-control mt-4 ml-5"}/>
                                <div className="invalid-feedback">{Validation.ProjectKey}</div>
                               
                            
                            <button type="button" className=" mt-4 btn btn-outline-primary" 
                            onClick={this.SaveProjectKey} disabled={this.state.PendingApi}>

                                {this.state.PendingApi? 
                                <span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>
                                 :null }  İleri
                            </button>

                        </div>
                    </form> 
                </div>
                <div className="product-device shadow-sm d-none d-md-block"></div>
                <div className="product-device product-device-2 shadow-sm d-none d-md-block"></div>
            </div>
            </div>
            </div>
        )
    }
}
