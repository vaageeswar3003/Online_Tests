import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Branch } from "src/Interfaces/Branch";
import { Section } from "src/Interfaces/Section";
import { environment } from "src/environments/environment";

@Injectable({
    providedIn: 'root'
})

export class InstitutionService {
    private readonly api = environment.apiUrl+'institution/';

    constructor(private http:HttpClient) { }

    // Branch methods

    getAllBranches(institutionId: number) {
        return this.http.get<Branch[]>(this.api+'get-branches-by-institution-id?institutionId='+institutionId);
    }

    addBranch(branch:Branch) {
        return this.http.post<Branch>(this.api+'add-branch-to-institution',branch);
    }

    updateBranch(branch:Branch) {
        return this.http.put<Branch>(this.api+'update-branch-in-institution',branch);
    }

    deleteBranch(branch:Branch) {
        return this.http.delete<Branch>(this.api+'delete-branch-in-institution',{body: branch});
    }

    // Section methods

    getAllSections(branchId: number) {
        return this.http.get<Section[]>(this.api+'get-sections-by-branch-id?branchId='+branchId);
    }

    addSection(section:Section) {
        return this.http.post<Section>(this.api+'add-section-to-branch',section);
    }

    updateSection(section:Section) {
        return this.http.put<Section>(this.api+'update-section-in-branch',section);
    }

    deleteSection(section:Section) {
        return this.http.delete<Section>(this.api+'delete-section-in-branch',{body: section});
    }
}