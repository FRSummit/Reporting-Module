import { autoinject } from "aurelia-framework";
import { AdminService } from "services/AdminService";
import { SignalrWrapper } from "signalrwrapper";
import toastr from "toastr";

@autoinject
export class Admin {
    pingmessage = "";
    ispinging = false;
    constructor(public adminService: AdminService, public singalrwrapper: SignalrWrapper) {}

    attached() {
        this.singalrwrapper.on("Pong", this.onPong);
    }

    detached() {
        this.singalrwrapper.off("Pong", this.onPong);
    }

    ping = async () => {
        try {
            await this.adminService.ping(this.pingmessage);
            this.ispinging = true;
        } catch(error) {
            toastr.error(error);
        }
    }

    onPong = (message: string) => {
        toastr.success(message);
        this.ispinging = false;
    }
}