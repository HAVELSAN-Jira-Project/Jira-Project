import React from 'react'

export default function Load() {
    return (
        <div>
            <h3>Veriler Hazırlanıyor...</h3><br/>
                    <div class="spinner-border text-primary" role="status">
                        <span class="sr-only"></span>
                    </div><br/><br/>
                    <strong className="mt-5">Lütfen Bekleyin</strong>
        </div>

    )
}
