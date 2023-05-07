export interface QuestionPaper {
    name:string,
    branch: number[],
    sectionsSelected: number[],
    multipleSections: boolean,
    sections: string[],
    bulitInKey: boolean,
    immediateResult: boolean,
    isTimeBound:boolean,
    testDuration: string
}