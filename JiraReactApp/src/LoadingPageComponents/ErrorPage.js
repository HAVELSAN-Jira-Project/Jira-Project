import React from 'react'
import Header from '../IntroComponents/Header'
import logo from '../error.png'


export default function ErrorPage(props) {

    const GoHomePage = ()=>{

        props.history.push("/");
    }

    return (
        <div>
            <Header />
            
                <div className="container-fluid bg-light">
                <div className="IntroPage position-relative overflow-hidden text-center bg-light">
                <div className="col-md-5  mx-auto my-5">
                <img src={logo} width={125} height={125} class="img-fluid" alt="Error" />
                    <h3 className="mt-4">Bir Hata Oluştu.</h3><br/>
                    <strong>Hata Şu Durumlardan Dolayı Meydana Gelmiş Olabilir.
                        Lütfen Aşağıdaki Durumları Kontrol Edin.</strong><br/>
                    <ul className="list-group mt-4">
                        <li className="list-group-item">
                            Girdiğiniz Proje Numarasına Ait Bir Proje Olmayabilir.
                        </li>

                        <li className="list-group-item">
                            Girdiğiniz Proje Numarasına Ait Bir Bug Olmayabilir.
                        </li>

                        <li className="list-group-item">
                           API Token Geçerliliğini Yitirmiş Olabilir.
                        </li>
                    </ul>
                    <button className="btn btn-outline-primary mt-3" onClick={()=>GoHomePage()}>Anasayfa</button>

                </div>
                <div className="product-device shadow-sm d-none d-md-block"></div>
                <div className="product-device product-device-2 shadow-sm d-none d-md-block"></div>
            </div>
            </div>
        </div>
    )
}
