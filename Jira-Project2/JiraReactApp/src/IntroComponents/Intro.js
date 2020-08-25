import React, { Component } from 'react'
import Header from './Header'
import Jumbotron from './Jumbotron'

export default class Intro extends Component {
    
    
    SkipProjectPage = ()=>{
        this.props.history.push("/ProjectKey");
        
    }

    render() {
        return (
            <div>
                <Header/>
                <Jumbotron ButtonClick = {this.SkipProjectPage}/>   
            </div>
        )
    }
}
