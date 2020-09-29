import { Container } from "aurelia-framework";
import { AuthService } from "../auth-service";
import { SignalrWrapper } from "signalrwrapper";

export function fetchWithAccessToken<T>(url: string): Promise<T> {
    const authservice = <AuthService>Container.instance.get(AuthService);
    console.log(authservice.getAccessToken());
    const headers = new Headers();
    headers.set("Authorization", `Bearer ${authservice.getAccessToken()}`);
    
    return fetch(url, {
            headers: headers
        })
        .then(response => {
            if (response.status === 200) {
                return response.json();
            }
            toastr.error(response.statusText);
            throw new Error(response.statusText);
        }, error => {
            throw error;
        });
}

export function fetchPostWithAccessToken(url: string, jsonBody?: string): Promise<void> {
    const authservice = <AuthService>Container.instance.get(AuthService);
    const signalrwrapper = <SignalrWrapper>Container.instance.get(SignalrWrapper);

    const headers = new Headers();
    headers.set("Authorization", `Bearer ${authservice.getAccessToken()}`);
    headers.set("SignalRConnectionId", signalrwrapper.signalrConnection.id);
    headers.set("Accept", "application/json");
    headers.set("Content-Type", "application/json");
    console.log('body: ');
    console.log(url);
    console.log(jsonBody);
    
    return fetch(url, {
            headers: headers,
            method: "POST",
            body: jsonBody,
        })
        .then(response => {
            console.log('----------FRS => fetchPostWithAccessToken----------');
            // console.log('headers : ');
            // console.log(headers);
            // console.log(jsonBody);
            // console.log('headers : ');
            console.log(response);
            // console.log('signalrwrapper: ');
            // console.log(signalrwrapper);
            // console.log(signalrwrapper.signalrConnection);
            // console.log(signalrwrapper.signalrConnection.id);
            console.log('----------FRS => fetchPostWithAccessToken----------');
            if (response.status === 200) {
                return;
            }
            if(response.status === 404) {
                throw Error("Not Found");
            }
        }, error => {
            console.log(error);
            throw error;
        });
}

export function fetchFileWithAccessToken(url: string): Promise<Blob> {
    const authservice = <AuthService>Container.instance.get(AuthService);

    const headers = new Headers();
    headers.set("Authorization", `Bearer ${authservice.getAccessToken()}`);
    
    return fetch(url, {
            headers: headers
        })
        .then(response => {
            if (response.status === 200) {
                return response.blob();
            }
        }, error => {
            console.log(error);
            throw error;
        });
}