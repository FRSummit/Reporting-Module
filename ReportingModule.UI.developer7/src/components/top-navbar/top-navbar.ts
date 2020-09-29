import { autoinject, containerless, customElement } from "aurelia-framework";
import { AuthService } from "auth-service";

@containerless
@autoinject
@customElement("top-navbar")
export class TopNavbar {
    constructor(public auth: AuthService) {}

    get isAuthenticated() {
        return this.auth.isAuthenticated;
    }
}