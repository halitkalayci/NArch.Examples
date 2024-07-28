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

import { CreateOperationClaimCommand } from '../model/models';
import { DeleteOperationClaimCommand } from '../model/models';
import { OperationClaim } from '../model/models';
import { UpdateOperationClaimCommand } from '../model/models';


import { Configuration }                                     from '../configuration';


export interface ApiOperationClaimsDeleteRequestParams {
    deleteOperationClaimCommand?: DeleteOperationClaimCommand;
}

export interface ApiOperationClaimsIdGetRequestParams {
    id: number;
}

export interface ApiOperationClaimsPostRequestParams {
    createOperationClaimCommand?: CreateOperationClaimCommand;
}

export interface ApiOperationClaimsPutRequestParams {
    updateOperationClaimCommand?: UpdateOperationClaimCommand;
}


export interface OperationClaimsServiceInterface {
    defaultHeaders: HttpHeaders;
    configuration: Configuration;

    /**
     * 
     * 
* @param requestParameters
     */
    apiOperationClaimsDelete(requestParameters: ApiOperationClaimsDeleteRequestParams, extraHttpRequestParams?: any): Observable<{}>;

    /**
     * 
     * 
*/
    apiOperationClaimsGet(extraHttpRequestParams?: any): Observable<Array<OperationClaim>>;

    /**
     * 
     * 
* @param requestParameters
     */
    apiOperationClaimsIdGet(requestParameters: ApiOperationClaimsIdGetRequestParams, extraHttpRequestParams?: any): Observable<{}>;

    /**
     * 
     * 
* @param requestParameters
     */
    apiOperationClaimsPost(requestParameters: ApiOperationClaimsPostRequestParams, extraHttpRequestParams?: any): Observable<{}>;

    /**
     * 
     * 
* @param requestParameters
     */
    apiOperationClaimsPut(requestParameters: ApiOperationClaimsPutRequestParams, extraHttpRequestParams?: any): Observable<{}>;

}