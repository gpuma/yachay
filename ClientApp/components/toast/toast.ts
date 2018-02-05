import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import { Student } from '../models'

@Component
export default class ToastComponent extends Vue {
    @Prop()
    msg: string;
    @Prop()
    msgType: string;
    
    successfulSave = false;
    failedSave = false;
    
    mounted() {
        if (this.msgType == "ok"){
            this.successfulSave = true;
        } else if (this.msgType == "error"){
            this.failedSave = true;
        }
        setTimeout(() => {
            this.successfulSave = false;
            this.failedSave = false;
        }, 4000);
    }
}