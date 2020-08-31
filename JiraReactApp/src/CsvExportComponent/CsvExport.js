import React from 'react'
import {CSVLink} from 'react-csv'

export const  CsvExport= (CsvData,FileName) =>{
    return (
        
        <button  type="button" className="btn btn-sm btn-outline-primary raunded">
            <CSVLink data={CsvData} filename={FileName}>Excel</CSVLink>
        </button>
    )
}
