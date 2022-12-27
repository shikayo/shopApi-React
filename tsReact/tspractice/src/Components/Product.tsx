import axios from 'axios'
import { Guid } from 'guid-typescript'
import React, {useState} from 'react'
import { IProduct } from '../models'

interface ProductProps{
    product: IProduct
}

export function Product({product}: ProductProps){
    
    const [details, setDetails]= useState(false)

    const btnBgClassName=details?'bg-blue-400': 'bg-yellow-400'

    const btnClasses=['py-2 px-4 border',btnBgClassName]

    return (
        <div className="border py-2 px-4 rounded flex flex-col items-center mb-2">
            <img src={product.Image} className="w-1/6" alt={product.Title}/>
            <p>{product.Title}</p>
            <p className="font-bold">{product.Price}$</p>
            <div className="flex justify-between">
            <button className={btnClasses.join(' ')} onClick={()=> setDetails(prev=>!prev)}>
                {details ? 'Hide Details' : "Show Details"}
                </button>
            <button className='py-2 px-4 border bg-red-400' onClick={DeleteProduct}>Delete</button>
            </div>

            {details && <div>
                <p>{product.Description}</p>
                <p>Rate:<span style={{fontWeight:'bold'}}>5</span></p>
                </div>}
        </div>
    )

    async function DeleteProduct(){
        await axios.post<IProduct>("https://localhost:7026/product/Delete",product)

        window.location.reload()
    }
}