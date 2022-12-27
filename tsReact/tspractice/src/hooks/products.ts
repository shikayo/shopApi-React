import {useEffect,useState} from 'react'
import { IProduct } from '../models'
import axios from 'axios'

export function useProducts() {
    async function fetchProducts() {
        try{
          setError('')
          setLoading(true)
          const response=await axios.get<IProduct[]>('https://localhost:7026/product')
          setProducts(response.data)
          setLoading(false)
        }
        catch(e: unknown){
          const error=e as any
          setLoading(false)
          setError(error.message)
        }
      }
      
      function addProduct(product:IProduct){
        setProducts(prev=>[...prev,product])
      }

      useEffect(()=>{
        fetchProducts()
      },[])
    
      const [products,setProducts]=useState<IProduct[]>([])
      const [loading,setLoading] =useState(false)
      const [error,setError]=useState('')

      return{products,error,loading,addProduct}
}