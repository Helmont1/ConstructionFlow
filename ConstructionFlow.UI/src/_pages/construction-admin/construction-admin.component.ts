import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LeftNavbarComponent } from '../../_components/left-navbar/left-navbar.component';
import { ConstructionService } from '../../_services/construction.service';
import { Construction } from '../../_models/construction.model';
import { FormsModule } from '@angular/forms';
import { ConstructionPhotoService } from '../../_services/construction-photo.service';
import { ConstructionPhoto } from '../../_models/construction-photo.model';
import { ActivityAdminComponent } from '../../_components/activity-admin/activity-admin.component';
import { Alert } from '../../_components/alert/alert.component';

@Component({
  selector: 'app-construction-admin',
  standalone: true,
  imports: [
    LeftNavbarComponent,
    FormsModule,
    ActivityAdminComponent
  ],
  templateUrl: './construction-admin.component.html',
  styleUrl: './construction-admin.component.scss',
})
export class ConstructionAdminComponent {
  id!: number;
  profile_image: ConstructionPhoto = {
    photo: 'https://static.thenounproject.com/png/4595376-200.png',
  };
  construction?: Construction;
  formater = new Intl.NumberFormat('pt-BR', {
    style: 'currency',
    currency: 'BRL',
  });
  readonly = true;
  statuses = [
    { id: 1, name: 'Não iniciada' },
    { id: 2, name: 'Em andamento' },
    { id: 3, name: 'Finalizada' },
  ];
  isFlashing = false;
  dates = {
    startDate: '',
    endDate: '',
  };
  alerts: Alert[] = [];

  constructor(
    private route: ActivatedRoute,
    private constructionService: ConstructionService,
    private constructionPhotoService: ConstructionPhotoService,
    private router: Router
  ) {
    this.route.params.subscribe((params) => {
      this.id = params['id'];
    });
    this.constructionService
      .getConstructionById(this.id)
      .subscribe((construction) => {
        this.construction = construction as Construction;
        this.dates.startDate = this.getFormattedDate(this.construction.startDate);
        this.dates.endDate = this.getFormattedDate(this.construction.endDate);
      });
    this.constructionPhotoService.getPhotosByConstructionId(this.id).subscribe((photo) => {
      if (photo && (photo as Array<Object>).length != 0) this.profile_image = photo as ConstructionPhoto;
    });
  }

  formatarParaReal(valor: string): string {
    let numero = parseFloat(valor);
    return this.formater.format(numero);
  }

  getDate(dateS: string) {
    let date = new Date(dateS);
    let dia = date.getUTCDate();
    let mes = date.getUTCMonth() + 1;
    let ano = date.getUTCFullYear();
    return (
      '' +
      (dia < 10 ? '0' + dia : dia) +
      '/' +
      (mes < 10 ? '0' + mes : mes) +
      '/' +
      ano
    );
  }

  getFormattedDate(date: Date): string {
    date = new Date(date);
    let dia = date.getUTCDate();
    let mes = date.getUTCMonth() + 1;
    let ano = date.getUTCFullYear();
    return (
      '' +
      ano +
      '-' +
      (mes < 10 ? '0' + mes : mes) +
      '-' +
      (dia < 10 ? '0' + dia : dia)
    );
  }

  getStatusName(statusId: number): string {
    if (statusId === 1) return 'Não iniciada';
    if (statusId === 2) return 'Em andamento';
    if (statusId === 3) return 'Finalizada';
    return '';
  }

  getStatusColor(statusId: number): string {
    if (statusId === 1) return 'red';
    if (statusId === 2) return 'yellow';
    if (statusId === 3) return 'green';
    return '';
  }

  isCnpj(): boolean {
    if (this.construction?.customer?.customerCnpj) return true;
    return false;
  }

  formatCnpj(cnpj: string): string {
    return cnpj.replace(
      /(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})/,
      '$1.$2.$3/$4-$5'
    );
  }

  formatCpf(cpf: string): string {
    return cpf.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/, '$1.$2.$3-$4');
  }

  isLate(): boolean {
    if (
      this.construction?.status?.id === 1 &&
      !this.compareDate(this.construction.startDate)
    )
      return true;
    return false;
  }

  compareDate(date: Date): boolean {
    let today = new Date();
    let dateToCompare = new Date(date);
    if (dateToCompare > today) return true;
    return false;
  }

  copyCode() {
    let code = this.construction?.search;
    if (code) {
      navigator.clipboard.writeText(code);
      this.flashButton();
    }
  }

  flashButton() {
    this.isFlashing = true;
    setTimeout(() => {
      this.isFlashing = false;
    }, 200); // Duração da animação
  }

  onFileSelected(event: any) {
    let file = event.target.files[0];
    let reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => {
      this.profile_image.photo = reader.result as string;
    };
  }

  verifyFinishDate(){
    let id = this.construction?.status?.id;
    let endDate = this.dates.endDate;
    let isFuture = this.compareDate(new Date(endDate));
    if ((id == 3 && isFuture) || (id != 3 && !isFuture) ) return false;
    return true;
  }

  deleteConstruction() {
    console.log(this.profile_image.id)
    if(this.profile_image.id)
      this.constructionPhotoService.deletePhoto(this.profile_image.id).subscribe();
    if(this.construction?.id)
      this.constructionService.deleteConstruction(this.construction.id).subscribe({
        next: () => {
          this.alerts.push({ type: 'success', message: 'Construção deletada com sucesso!' });
          this.router.navigate(['/profile'], {
            queryParams: { data: JSON.stringify(this.alerts) },
          });
        },
        error: (error) => {
          this.alerts.push({ type: 'danger', message: 'Erro ao deletar construção' });
          this.router.navigate(['/profile'], {
            queryParams: { data: JSON.stringify(this.alerts) },
          });
        }
    });
  }

  toggle() {
    this.readonly = !this.readonly;
    if (this.readonly) {
      let construction: Construction = {
        id: this.construction!.id,
        statusId: this.construction!.status!.id,
        startDate: new Date(this.dates.startDate),
        endDate: new Date(this.dates.endDate),
        customerId: parseInt(this.construction!.customer!.id!),
        userId: this.construction!.user!.id!,
        title: this.construction!.title,
        search: this.construction!.search,
        budget: this.construction!.budget,
      };
      this.constructionService.editConstruction(construction).subscribe();
      if (this.profile_image.id) {
        let image: ConstructionPhoto = {
          photo: this.profile_image.photo,
          constructionId: this.profile_image.construction!.id,
          id: this.profile_image.id,
        };
        this.constructionPhotoService.updatePhoto(image).subscribe();
      } else {
        let image: ConstructionPhoto = {
          photo: this.profile_image.photo,
          constructionId: this.construction!.id,
        };
        this.constructionPhotoService.createPhoto(image).subscribe();
      }
    }
  }
}
