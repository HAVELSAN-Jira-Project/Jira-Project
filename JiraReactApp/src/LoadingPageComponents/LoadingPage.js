import React, {useState,useEffect } from 'react'
import Header from '../IntroComponents/Header'
import Load from './Load'
import {ClearBugs,ClearLogs,AddBugs,AddLogs} from '../Requests/Requests'



export default function LoadingPage(props) {
    
    const[ClearTables,setClearTables] = useState(false);    //STATE MANTIĞINDA. DEĞERİ HER DEĞİŞTİĞİNDE COMPONENT
                                                            //YENİDEN RENDER EDİLİR.
    const[AddTables,setAddTables] = useState(false);        //TABLOLARIN SETLENMESİ İÇİN

    const[TableErrors,setTableErrors] = useState(false);   //TABLOLAR SETLENİRKEN HATA DÖNMESİ 
 
    const[PendingApi,setPendingApi] = useState(false);
    
      
    //VERİTABANI TEMİZLEME REQUESTLERİ
    useEffect(()=>{                                    //SAYFA HER YENİLENDİĞİNDE (RENDER EDİLMESİ DE DAHİL) ÇALIŞIR.
        if(!ClearTables){
            ClearLogs()
            .then(response=>{
                ClearBugs();
                setClearTables(true)
            })
        }
       
        
    })
    
    //VERİTABANI EKLEME REQUESTLERİ
    useEffect(()=>{  
        if(AddTables){
            setPendingApi(true) //YÜKLEME EKRANINI AÇ
            AddBugs()
            .then(response=>{
                AddLogs()
                .then(response=>{
                    setAddTables(false)
                    setTimeout(() => {
                        props.history.push('/Home')
                        }, 1500);
                })
                .catch(error=>{
                    setTableErrors(true)
                })
            })
            .catch(error=>{
                setTableErrors(true)
            })
                  
        }                       
    // eslint-disable-next-line react-hooks/exhaustive-deps
    },[AddTables]);


    //ERROR DURUMUNDA YÖNLENDİRME
    useEffect(()=>{
        if(TableErrors)
        setTimeout(() => {
            props.history.push('/Error')
            }, 1500);
    },[TableErrors])


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