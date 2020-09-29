import { Redirect, NavigationInstruction } from "aurelia-router";
import { AuthService } from "auth-service";
import { autoinject } from "aurelia-framework";

@autoinject
export class RolesAuthoriseStep {
    constructor(public auth: AuthService){}

    run(routingContext: NavigationInstruction, next) {
        const userRoles = this.auth.roles;
        if (routingContext.getAllInstructions()
                .some(r => r.config.roles &&
                            r.config.roles.length > 0 &&
                            (r.config.roles.filter(role => userRoles.includes(role)).length == 0)
                )
        ) {
            if (routingContext.previousInstruction) {
                return next.cancel();
            } else {
                return next.cancel(new Redirect("dashboard"));
            }
        }

        return next();
    }
}