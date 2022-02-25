export default interface IContestData {
    contest: number;
    competitorWhite: string;
    competitorBlue: string;
    iponWhite: number;
    wazaariWhite: number;
    iponBlue: number;
    wazaariBlue: number;
}

export interface Competitor {
    name: string;
    score: number;
    won: number;
    position: number;
}

export interface IRoundRobinContestData extends IContestData {
    competitors: Competitor[];
}