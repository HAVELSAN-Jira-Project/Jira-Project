import React, {useState,useEffect } from 'react'
import Header from '../IntroComponents/Header'
import Load from './Load'
import {ClearBugs,ClearLogs,AddBugs,AddLogs} from '../Requests/Requests'



export default function LoadingPage(props) {
    
                                                            //STATE MANTIĞINDA. DEĞERİ HER DEĞİŞTİĞİNDE COMPONENT
                                                            //YENİDEN RENDER EDİLİR.
                                                       

    const[AddTables,setAddTables] = useState(false);        //TABLOLARIN SETLENMESİ İÇİN
 
    const[PendingApi,setPendingApi] = useState(false);
    
      
    
    
    //VERİTABANI EKLEME REQUESTLERİ
    useEffect(()=>{  
        if(AddTables){
            setPendingApi(true) //YÜKLEME EKRANINI AÇ
            ClearLogs()
            .then(response=>{
                ClearBugs()
                .then(response=>{
                    AddBugs()
                    .then(response=>{
                        AddLogs()
                        .then(response=>{
                            setTimeout(() => {
                                props.history.push('/Bugs')
                                }, 1500);
                        })
                        .catch(error=>{
                            setTimeout(() => {
                                props.history.push('/Error')
                                }, 1500);
                        })
                    })
                    .catch(error=>{
                        setTimeout(() => {
                            props.history.push('/Error')
                            }, 1500);
                    })
                })
                .catch(error=>{
                    setTimeout(() => {
                        props.history.push('/Error')
                        }, 1500);
                })
            })

        }                         
    // eslint-disable-next-line react-hooks/exhaustive-deps
    },[AddTables]);


    return (
        <div>
            <Header />
            <div className="jumbotron text-center">
            {PendingApi ? <Load/> : null}
            <button className="btn btn-outline-primary mt-3" disabled={PendingApi} onClick={()=>setAddTables(true)}>
            Verileri Hazırla</button>
            
            </div>
            
        </div>
      
    );
  }