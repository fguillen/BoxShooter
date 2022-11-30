using UnityEngine;

// From here: https://www.reddit.com/r/Unity3D/comments/m44cqp/want_to_throw_an_error_if_getcomponent_returns/
public static class GetComponentSecureExtension {
    //  "where T : Component" is necessary due to how Unity overrides the "==" operator. Otherwise, null check fails.
    // https://answers.unity.com/questions/1243356/getcomponent-returns-null-however-comparison-to-nu.html
    public static T GetComponentThrowIfNotFound<T>(this GameObject m) where T : Component {
        T c = m.GetComponent<T>();
        if (c == null) {
            throw new System.Exception($"Missing {typeof(T).Name} component.");
        }
        return c;
    }

    public static T GetComponentThrowIfNotFound<T>(this Component m) where T : Component {
        T c = m.GetComponent<T>();
        if (c == null) {
            throw new System.Exception($"Missing {typeof(T).Name} component.");
        }
        return c;
    }

    public static T GetComponentInChildrenThrowIfNotFound<T>(this GameObject m) where T : Component {
        T c = m.GetComponentInChildren<T>();

        if (c == null) {
            throw new System.Exception($"Missing {typeof(T).Name} component.");
        }

        return c;
    }

    public static T GetComponentInChildrenThrowIfNotFound<T>(this Component m) where T : Component {
        T c = m.GetComponentInChildren<T>();

        if (c == null) {
            throw new System.Exception($"Missing {typeof(T).Name} component.");
        }

        return c;
    }
}
