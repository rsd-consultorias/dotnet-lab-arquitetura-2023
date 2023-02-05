import { Component, TemplateRef } from '@angular/core';

import { NgFor, NgIf, NgTemplateOutlet } from '@angular/common';
import { NgbToastModule } from '@ng-bootstrap/ng-bootstrap';
import { AlertService } from '../services/alert.service';

@Component({
	selector: 'app-toasts',
	standalone: true,
	imports: [NgbToastModule, NgIf, NgTemplateOutlet, NgFor],
	styles: [`:host {
		position: fixed;
		top: 0;
		right: 0;
		margin: 0.5em;
		z-index: 1200;
	  }`],
	template: `
		<ngb-toast
			*ngFor="let toast of toastService.toasts"
			[class]="toast.classname"
			[autohide]="true"
			[delay]="toast.delay || 5000"
			(hidden)="toastService.remove(toast)">
			<ng-template [ngIf]="isTemplate(toast)" [ngIfElse]="text">
				<ng-template [ngTemplateOutlet]="toast.textOrTpl"></ng-template>
			</ng-template>

			<ng-template #text>{{ toast.textOrTpl }}</ng-template>
		</ngb-toast>
	`,
	host: { class: 'toast-container', style: 'z-index: 1200' },
})
export class ToastsContainer {
	constructor(public toastService: AlertService) { }

	isTemplate(toast: any) {
		return toast.textOrTpl instanceof TemplateRef;
	}
}