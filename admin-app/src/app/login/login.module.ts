import { NgxSpinnerService } from 'ngx-spinner';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';

import { LoginRoutingModule } from './login-routing.module';
import { LoginComponent } from './login.component';

@NgModule({
    imports: [
        CommonModule,
        TranslateModule,
        LoginRoutingModule],
    declarations: [LoginComponent],
    providers:[NgxSpinnerService]
})
export class LoginModule {}
