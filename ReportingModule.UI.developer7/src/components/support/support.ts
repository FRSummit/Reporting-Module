import { autoinject } from 'aurelia-framework';
import { AuthService } from '../../auth-service';

@autoinject
export class Support {
    isAuthenticated = false;
    constructor(private auth: AuthService) {
        this.isAuthenticated = auth.isAuthenticated;
    
        auth.authNotifier.addListener('authChange', this.authChangeHandler);
    }

    private authChangeHandler(state) {
        this.isAuthenticated = state.authenticated;
    }

    attached(){
    }
}