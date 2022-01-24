using UnityEngine;

public class ProductivityUnit : Unit {
    float productivityMultiplier = 2;
    ResourcePile currentPile;

    protected override void BuildingInRange() {
        if (currentPile == null) {
            ResourcePile pile = m_Target as ResourcePile;

            if (pile != null) {
                currentPile = pile;
                currentPile.ProductionSpeed *= productivityMultiplier;
            }
        }
    }

    void ResetProductivity() {
        if (currentPile != null) {
            currentPile.ProductionSpeed /= productivityMultiplier;
            currentPile = null;
        }
    }

    public override void GoTo(Building target) {
        ResetProductivity();
        base.GoTo(target);
    }

    public override void GoTo(Vector3 position) {
        ResetProductivity();
        base.GoTo(position);
    }
}
