import { Evento } from "./Evento";
import { LocationStrategy } from "@angular/common"

export interface Lote {

    id: number;
    nome: string;
    preco: number;
    dataInicio?:  Date;
    dataFim?:  Date;
    quantidade: number;
    eventoId: number;
    evento:  Evento[];
}
