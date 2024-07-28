/**
 * WebAPI
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 1.0
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */
import { HttpHeaders }                                       from '@angular/common/http';

import { Observable }                                        from 'rxjs';

import { CreateBrandCommand } from '../model/models';
import { UpdateBrandCommand } from '../model/models';


import { Configuration }                                     from '../configuration';


export interface ApiBrandsGetRequestParams {
    pageIndex?: number;
    pageSize?: number;
}

export interface ApiBrandsIdDeleteRequestParams {
    id: string;
}

export interface ApiBrandsIdGetRequestParams {
    id: string;
}

export interface ApiBrandsPostRequestParams {
    createBrandCommand?: CreateBrandCommand;
}

export interface ApiBrandsPutRequestParams {
    updateBrandCommand?: UpdateBrandCommand;
}


export interface BrandsServiceInterface {
    defaultHeaders: HttpHeaders;
    configuration: Configuration;

    /**
     * 
     * 
* @param requestParameters
     */
    apiBrandsGet(requestParameters: ApiBrandsGetRequestParams, extraHttpRequestParams?: any): Observable<{}>;

    /**
     * 
     * 
* @param requestParameters
     */
    apiBrandsIdDelete(requestParameters: ApiBrandsIdDeleteRequestParams, extraHttpRequestParams?: any): Observable<{}>;

    /**
     * 
     * 
* @param requestParameters
     */
    apiBrandsIdGet(requestParameters: ApiBrandsIdGetRequestParams, extraHttpRequestParams?: any): Observable<{}>;

    /**
     * 
     * 
* @param requestParameters
     */
    apiBrandsPost(requestParameters: ApiBrandsPostRequestParams, extraHttpRequestParams?: any): Observable<{}>;

    /**
     * 
     * 
* @param requestParameters
     */
    apiBrandsPut(requestParameters: ApiBrandsPutRequestParams, extraHttpRequestParams?: any): Observable<{}>;

}