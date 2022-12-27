import {Guid} from "guid-typescript"

export interface IProduct{
    Id?: Guid
    Title: string
    Price: number
    Description: string
    Category: string
    Image:string
}