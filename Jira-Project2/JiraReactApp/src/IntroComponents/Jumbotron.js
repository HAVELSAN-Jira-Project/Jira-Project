import React, { Component } from 'react'

export default class Jumbotron extends Component {

    render() {
        const {ButtonClick} = this.props;
        return (
            
                 <Container-fluid className="bg-light">
                <div className="IntroPage position-relative overflow-hidden p-3  text-center bg-light">
                <div className="col-md-5 p-lg-5 mx-auto my-5">
                    <h1 className="display-4 font-weight-normal">Jira Helper</h1>
                    <p className="lead font-weight-normal mt-3">Jira Helper ile Projelerinizdeki Bugları Takip Etmek Artık Çok Kolay! Proje numaranı gir, gerisini Jira Helper'a bırak. Senin için tüm bugları ve detaylı analizleri getirsin.</p>
                    <button className=" mt-2 btn btn-outline-primary" onClick={ButtonClick}>Başlayalım!</button>
                    
                </div>
                <div className="product-device shadow-sm d-none d-md-block"></div>
                <div className="product-device product-device-2 shadow-sm d-none d-md-block"></div>
            </div>
            </Container-fluid>
            
        )
    }
}
