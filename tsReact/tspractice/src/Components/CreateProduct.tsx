import axios from "axios";
import React, { useState } from "react";
import { IProduct } from "../models";
import { ErrorMessage } from "./ErrorMessage";

const productData: IProduct ={
    Title: '',
    Price: 0.0,
    Description: '',
    Image: '',
    Category: '',
}

interface CreateProductProps{
    onCreate:(product: IProduct)=>void
}

export function CreateProduct({onCreate}:CreateProductProps){
    const [title,setTitle]=useState('')
    const [price,setPrice]=useState(0)
    const [description,setDescription]=useState('')
    const [image,setImage]=useState('')
    const [category,setCategory]=useState('')
    const [error,setError]=useState('')

    const sumbitHandler= async (event: React.FormEvent)=>{
        event.preventDefault()
        setError('')

        if (title.trim().length==0){
            setError('Please enter valid data')
            return
        }
        if (description.trim().length==0){
            setError('Please enter valid data')
            return
        }
        if (image.trim().length==0){
            setError('Please enter valid data')
            return
        }
        if (category.trim().length==0){
            setError('Please enter valid data')
            return
        }

        productData.Title=title
        productData.Price=price
        productData.Description=description
        productData.Image=image
        productData.Category=category

        const response =await axios.post<IProduct>('https://localhost:7026/product',productData)

        onCreate(response.data)

        window.location.reload()
    }

    return(
        <form onSubmit={sumbitHandler}>
            <input type="text" className="border py-2 px-4 mb-2 w-full outline-0" placeholder="Enter product title..." value={title} onChange={event=>setTitle(event.target.value)} />
            <input type="text" className="border py-2 px-4 mb-2 w-full outline-0" placeholder="Enter product price" value={price} onChange={event=>setPrice(Number(event.target.value))} />
            <input type="text" className="border py-2 px-4 mb-2 w-full outline-0" placeholder="Enter product desc" value={description} onChange={event=>setDescription(event.target.value)} />
            <input type="text" className="border py-2 px-4 mb-2 w-full outline-0" placeholder="Enter product image" value={image} onChange={event=>setImage(event.target.value)} />
            <input type="text" className="border py-2 px-4 mb-2 w-full outline-0" placeholder="Enter product category" value={category} onChange={event=>setCategory(event.target.value)} />
            {error &&<ErrorMessage error={error}/>}
            <button className="py-2 px-4 border bg-yellow-400 hover:text-white">Create</button>
        </form>
    )
}