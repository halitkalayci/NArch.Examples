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

import { CreateRequestConfigCommand } from '../model/models';
import { GetListRequestConfigListItemDtoGetListResponse } from '../model/models';
import { UpdateRequestConfigCommand } from '../model/models';


import { Configuration }                                     from '../configuration';


export interface ApiRequestConfigsGetRequestParams {
    pageIndex?: number;
    pageSize?: number;
}

export interface ApiRequestConfigsIdDeleteRequestParams {
    id: string;
}

export interface ApiRequestConfigsIdGetRequestParams {
    id: string;
}

export interface ApiRequestConfigsPostRequestParams {
    createRequestConfigCommand?: CreateRequestConfigCommand;
}

export interface ApiRequestConfigsPutRequestParams {
    updateRequestConfigCommand?: UpdateRequestConfigCommand;
}


export interface RequestConfigsServiceInterface {
    defaultHeaders: HttpHeaders;
    configuration: Configuration;

    /**
     * 
     * 
* @param requestParameters
     */
    apiRequestConfigsGet(requestParameters: ApiRequestConfigsGetRequestParams, extraHttpRequestParams?: any): Observable<GetListRequestConfigListItemDtoGetListResponse>;

    /**
     * 
     * 
* @param requestParameters
     */
    apiRequestConfigsIdDelete(requestParameters: ApiRequestConfigsIdDeleteRequestParams, extraHttpRequestParams?: any): Observable<{}>;

    /**
     * 
     * 
* @param requestParameters
     */
    apiRequestConfigsIdGet(requestParameters: ApiRequestConfigsIdGetRequestParams, extraHttpRequestParams?: any): Observable<{}>;

    /**
     * 
     * 
* @param requestParameters
     */
    apiRequestConfigsPost(requestParameters: ApiRequestConfigsPostRequestParams, extraHttpRequestParams?: any): Observable<{}>;

    /**
     * 
     * 
* @param requestParameters
     */
    apiRequestConfigsPut(requestParameters: ApiRequestConfigsPutRequestParams, extraHttpRequestParams?: any): Observable<{}>;

    /**
     * 
     * 
*/
    apiRequestConfigsReloadGet(extraHttpRequestParams?: any): Observable<{}>;

}