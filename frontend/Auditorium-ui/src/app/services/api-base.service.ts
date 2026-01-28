import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ApiError } from "../models/api-error.model";
import { throwError } from "rxjs";

@Injectable({ providedIn:'root'})
export class ApiBaseService{
    constructor(protected http:HttpClient){}
    protected handleError(error: HttpErrorResponse){
        const apiError: ApiError = {
            status: error.status,
            message: error.message
        };
        if(error.error?.errors){
            apiError.message = 'Validation Failed';
            apiError.validationErrors = error.error.errors;
        }else if (error.error?.error){
            apiError.message = error.error.error;
        }
        return throwError(()=>apiError);
    }
}
