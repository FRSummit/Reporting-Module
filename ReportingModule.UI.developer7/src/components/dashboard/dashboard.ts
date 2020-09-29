import { Router } from "aurelia-router";
import { autoinject } from "aurelia-framework";
import { AuthService } from "auth-service";

@autoinject
export class Dashboard {
    constructor(public router: Router, public auth: AuthService){}
}